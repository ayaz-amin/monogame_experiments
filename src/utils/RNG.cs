namespace mtts;

class RNG {
    private uint seed;
	private const uint BIT_NOISE1 = 0x68E31DA4;
	private const uint BIT_NOISE2 = 0xB5297A4D;
	private const uint BIT_NOISE3 = 0x1B56C4E9;
	public RNG(int seed) {
		this.seed = System.Convert.ToUInt32(seed);
	}

	public float Sample(int pos_x) {
		uint mangled = System.Convert.ToUInt32(pos_x);
		mangled *= BIT_NOISE1;
		mangled += seed;
		mangled ^= (mangled >> 8);
		mangled += BIT_NOISE2;
		mangled ^= (mangled << 8);
		mangled *= BIT_NOISE3;
		mangled ^= (mangled >> 8);
		return (float)(mangled)/uint.MaxValue;
	}
}