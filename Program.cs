using System.Diagnostics.CodeAnalysis;
using static NoNullValues;
using static ExampleFunctions;

#region Functions
/// <Summary>
/// Either returns true and sets the output to "Meow!", or returns false and sets the output to null.
/// Note the NotNullWhen attribute. This should tell the compiler that the value is not null when the function returns <c>true</c>
/// </Summary>
/// <Param name="ExampleInt">If even, the output will not be null. Otherwise, it will be.</Param>
/// <Param name="OutputString">The string to set.</Param>
/// <Returns><c>true</c> if the value is not null, <c>false</c> otherwise.</Returns>
bool Example_NullWhenTrue(int ExampleInt, [NotNullWhen(false)] out string? OutputString) {
    if (ExampleInt % 2 == 0) {
        OutputString = "Meow!";
        return false;
    } else {
        OutputString = null;
        return true;
    }
}

/// <Summary>
/// A function to test the string (class) values with
/// This function is used with the String class
/// </Summary>
/// <Param name="input">A non-null string to display</Param>
/// <Exception cref="System.ArgumentNullException">Thrown when the string is null. Used for the examples that should throw exceptions when running the project.</Exception>
void TestString([MaybeNull]string input) {
    if (input == null) {
        throw new ArgumentNullException(nameof(input));
    }
    Console.Out.WriteLine(input);
}
#endregion

#region Tests with functions that return true when the output is null and return false when the output isn't null
// The nullable strings to test with.
string? NotNullTest;
string? AlwaysNullTest;

// Test the function call.
bool IsNull_ShouldNotBeNull = Example_NullWhenTrue(2, out NotNullTest);
bool IsNull_ShouldBeNull = Example_NullWhenTrue(1, out AlwaysNullTest);
bool IsNull_ShouldNotBeNull_NewVar = Example_NullWhenTrue(2, out var OutputStringNewVar);

// Check if each of the test values are null based on the function return value.
// Then call a function that requires a non-null string, but only when the test values aren't null.

// The below function call should always run because the value will never be null.
if (!IsNull_ShouldNotBeNull) {
    TestString(NotNullTest);
}

// The below function call should never run as the value will always be null
if (!IsNull_ShouldBeNull) {
    TestString(AlwaysNullTest);
}

if (!IsNull_ShouldNotBeNull_NewVar) {
    TestString(OutputStringNewVar);
}
#endregion
#region These should throw exceptions and produce warnings
// The below functions should give warnings as they will only run the values are null
// Since these will throw exceptions, only one of them is run at a time.

// Check if each of the test values are null based on the function return value.
// Then call a function that requires a non-null string/integer, but only when the test values are null.
// This should trigger warnings from the compiler, OmniSharp, Visual Studio, etc.

// The below function call should always run because the value will never be null.
if (IsNull_ShouldNotBeNull) {
    TestString(NotNullTest);
}
// The below function call should never run as the value will always be null
if (IsNull_ShouldBeNull) {
    TestString(AlwaysNullTest);
}
#endregion
