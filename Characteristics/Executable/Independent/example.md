```csharp
   @Test
	public void testWriteFile() {
		String path = "D:\\Dropbox\\Code\\pruebasUnitariasConJMockit\\data\\prueba";
		DecisionTreeBoard decisionTreeBoard = new DecisionTreeBoard();
		decisionTreeBoard.put(new Coordinate(1, 1), Color.XS);
		decisionTreeBoard.put(new Coordinate(2, 2), Color.OS);
		decisionTreeBoard.put(new Coordinate(1, 2), Color.XS);
		decisionTreeBoard.writeFile(path);
		int[][] recorded = readFile(path);
		int[][] expected = new int[][] { { 2, 2, 2, }, { 2, 0, 0, }, { 2, 2, 1, }, };
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				assertEquals("" + i + "-" + j, expected[i][j], recorded[i][j]);
			}
		}
	}
```