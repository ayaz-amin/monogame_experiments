namespace mtts;

class Map {
    private int[] data;
	private int map_width;
	private int map_height;
	
	public Map(int _map_width, int _map_height) {
		map_width = _map_width;
		map_height = _map_height;
		data = new int[_map_width * _map_height];
		for (int x=0; x < _map_width; x++) {
			for (int y=0; y < _map_height; y++) {
				data[y * _map_width + x] = x;
			}
		}
	}

	public int GetData(int pos_x, int pos_y) {
		return data[pos_y * map_width + pos_x];
	}
}