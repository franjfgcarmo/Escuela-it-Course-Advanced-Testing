```csharp
    @Test
	public void testFactorial() {
		testFactoria(0, 1);
		testFactoria(1, 1);
		testFactoria(1, 20);
	}

	public void testFactoria(long value, long expected) {
		System.out.println("REQUIREMENTS: " + value + "!=" + expected);
		System.out.println("SYSTEM: " + value + "!=" + Combinatorics.factorial(value));
		assertThat(Combinatorics.factorial(value), is(expected));
	}
```