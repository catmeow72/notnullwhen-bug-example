using System.Diagnostics.CodeAnalysis;

bool Example([NotNullWhen(true)] out string? output) {
  output = "Hello, world!";
  return true;
}

void RequiresNonNull(string input) {
	Console.WriteLine(input);
}

bool isNotNull = Example(out var output);

if (isNotNull) {
	RequiresNonNull(output);
}
