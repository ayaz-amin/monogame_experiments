using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace mtts;

class AnimationState {
    private Rectangle[] sources;
	public int id;
	private int frame_num;
	private int max_frames;
	private float frame_time;
	private int increment = 1;
	
	public AnimationState(Rectangle[] sources, int id) {
		this.sources = sources;
		this.id = id;
		this.frame_num = 0;
		this.max_frames = sources.Length;
		this.frame_time = 0.0f;
	}

	public void Reset() {
		this.frame_num = 0;
		this.frame_time = 0.0f;
	}
	
	public void Update(GameTime gameTime) {
		this.frame_time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
		if(this.frame_time >= 200.0f) {
			this.frame_time = 0.0f;
			this.frame_num += this.increment;
			this.frame_num %= this.max_frames;
		}
	}

	public Rectangle Frame {
		get {
			return this.sources[this.frame_num];
		}
	}
}