using System.Diagnostics.CodeAnalysis;

#region Functions
/// <Summary>
/// Either returns true and sets the output to -1, or returns false and sets the output to null.
/// Note the NotNullWhen attribute. This should tell the compiler that the value is not null when the function returns <c>false</c>
/// </Summary>
/// <Param name="ExampleInt">If even, the output will not be null. Otherwise, it will be.</Param>
/// <Param name="OutputString">The string to set.</Param>
/// <Returns><c>true</c> if the value is null, <c>false</c> otherwise.</Returns>
bool Example_Struct(int ExampleInt, [NotNullWhen(true)] out int? OutputInt) {
    if (ExampleInt % 2 == 0) {
        OutputInt = -1;
        return true;
    } else {
        OutputInt = null;
        return false;
    }
}
/// <Summary>
/// A function to test the int (struct) values with
/// This function is used with the Int32 class
/// </Summary>
/// <Param name="input">A non-null integer to display</Param>
/// <Exception cref="System.ArgumentNullException">Thrown when the integer is null. Used for the examples that should throw exceptions when running the project.</Exception>
void TestInt([DisallowNull]int? input) {
    if (!input.HasValue) {
        throw new ArgumentNullException(nameof(input));
    }
    Console.Out.WriteLine("The integer is: {0}", input.Value);
}
#endregion
#region Struct tests

// The nullable strings to test with.
int? NotNullStructTest;
int? AlwaysNullStructTest;

// Test the function call.
bool ShouldNotBeNull_Struct = Example_Struct(2, out NotNullStructTest);
bool ShouldBeNull_Struct = Example_Struct(1, out AlwaysNullStructTest);

// Check if each of the test values are null based on the function return value.
// Then call a function that requires a non-null integer, but only when the test values aren't null.

// The below function call should always run because the value will never be null.
if (ShouldNotBeNull_Struct) {
    TestInt(NotNullStructTest);
}

// The below function call should never run as the value will always be null
if (ShouldBeNull_Struct) {
    TestInt(NotNullStructTest);
}
#endregion
#region These should throw exceptions and produce warnings
// The below functions should give warnings as they will only run the values are null
// Since these will throw exceptions, only one of them is run at a time.

// Check if each of the test values are null based on the function return value.
// Then call a function that requires a non-null string/integer, but only when the test values are null.
// This should trigger warnings from the compiler, OmniSharp, Visual Studio, etc.

// The below function call should never run because the value will never be null.
if (!ShouldNotBeNull_Struct) {
    TestInt(NotNullStructTest);
}
// The below function call should always run as the value will always be null
if (!ShouldBeNull_Struct) {
    TestInt(NotNullStructTest);
}
#endregion
