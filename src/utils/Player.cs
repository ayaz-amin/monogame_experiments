using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace mtts;

class Player {
    public Texture2D spritesheet;
	public Vector2 position;

	private AnimationState idle_right;
	private AnimationState idle_left;
	private AnimationState idle_up;
	private AnimationState idle_down;

	private AnimationState walk_right;
	private AnimationState walk_left;
	private AnimationState walk_up;
	private AnimationState walk_down;
	
	private AnimationState current_animation_state;

	enum PlayerState {
		IDLE_RIGHT,
		IDLE_LEFT,
		IDLE_UP,
		IDLE_DOWN,

		WALK_RIGHT,
		WALK_LEFT,
		WALK_UP,
		WALK_DOWN
	}
	
	public Player(Texture2D spritesheet, Vector2 position) {
		this.spritesheet = spritesheet;
		this.position = position;

		this.idle_right = new AnimationState(
		    new Rectangle[] {new Rectangle(32, 96, 32, 48)}, 0
		);

		this.idle_left = new AnimationState(
			new Rectangle[] {new Rectangle(32, 48, 32, 48)}, 1
		);

		this.idle_up = new AnimationState(
			new Rectangle[] {new Rectangle(32, 144, 32, 48)}, 2
		);

		this.idle_down = new AnimationState(
			new Rectangle[] {new Rectangle(32, 0, 32, 48)}, 3
		);

		Rectangle[] wr_rects = new Rectangle[4];
		wr_rects[0] = new Rectangle(0, 96, 32, 48);
		wr_rects[1] = new Rectangle(32, 96, 32, 48);
		wr_rects[2] = new Rectangle(64, 96, 32, 48);
		wr_rects[3] = new Rectangle(32, 96, 32, 48);
		this.walk_right = new AnimationState(wr_rects, 4);

		Rectangle[] wl_rects = new Rectangle[4];
		wl_rects[0] = new Rectangle(0, 48, 32, 48);
		wl_rects[1] = new Rectangle(32, 48, 32, 48);
		wl_rects[2] = new Rectangle(64, 48, 32, 48);
		wl_rects[3] = new Rectangle(32, 48, 32, 48);
		this.walk_left = new AnimationState(wl_rects, 5);

		Rectangle[] wu_rects = new Rectangle[4];
		wu_rects[0] = new Rectangle(0, 144, 32, 48);
		wu_rects[1] = new Rectangle(32, 144, 32, 48);
		wu_rects[2] = new Rectangle(64, 144, 32, 48);
		wu_rects[3] = new Rectangle(32, 144, 32, 48);
		this.walk_up = new AnimationState(wu_rects, 6);

		Rectangle[] wd_rects = new Rectangle[4];
		wd_rects[0] = new Rectangle(0, 0, 32, 48);
		wd_rects[1] = new Rectangle(32, 0, 32, 48);
		wd_rects[2] = new Rectangle(64, 0, 32, 48);
		wd_rects[3] = new Rectangle(32, 0, 32, 48);
		this.walk_down = new AnimationState(wd_rects, 7);
		
		this.current_animation_state = this.idle_down;
	}

	public void SetAnimationIdle() {
		switch(this.current_animation_state.id) {
			case (int)PlayerState.WALK_RIGHT: {
				this.current_animation_state = this.idle_right;
				this.walk_right.Reset();
				break;
			}

			case (int)PlayerState.WALK_LEFT: {
				this.current_animation_state = this.idle_left;
				this.walk_left.Reset();
				break;
			}

			case (int)PlayerState.WALK_UP: {
				this.current_animation_state = this.idle_up;
				this.walk_up.Reset();
				break;
			}

			case (int)PlayerState.WALK_DOWN: {
				this.current_animation_state = this.idle_down;
				this.walk_down.Reset();
				break;
			}
		}
	}

	public void Update(GameTime gameTime) {
	    float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
		
		if(Keyboard.GetState().IsKeyDown(Keys.D)) {
		    this.position.X += 500.0f * dt;
			this.current_animation_state = this.walk_right;
		}
			
		else if(Keyboard.GetState().IsKeyDown(Keys.A)) {
		    this.position.X -= 500.0f * dt;
			this.current_animation_state = this.walk_left;
		}
		
		else if(Keyboard.GetState().IsKeyDown(Keys.W)) {
		    this.position.Y -= 500.0f * dt;
			this.current_animation_state = this.walk_up;
		}

		else if(Keyboard.GetState().IsKeyDown(Keys.S)) {
		    this.position.Y += 500.0f * dt;
			this.current_animation_state = this.walk_down;
		}

		else SetAnimationIdle();
		this.current_animation_state.Update(gameTime);
	}

	public Rectangle Frame {
		get {
			return this.current_animation_state.Frame;
		}
	}
}