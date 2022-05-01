using System.Diagnostics.CodeAnalysis;
using static NoNullValues;
using static ExampleFunctions;

#region Tests with functions that return true when the output is null and return false when the output isn't null
// The nullable strings to test with.
string? NotNullTest;
string? AlwaysNullTest;
string? PossiblyNullTest;

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

#region Tests with functions that return true when the output isn't null and return false when the output is null

// The nullable strings to test with.
string? NotNullTest2;
string? AlwaysNullTest2;
string? PossiblyNullTest2;

// Test the function call.
bool IsNotNull_ShouldNotBeNull = Example_NullWhenFalse(2, out NotNullTest2);
bool IsNotNull_ShouldBeNull = Example_NullWhenFalse(1, out AlwaysNullTest2);
bool IsNotNull_ShouldNotBeNull_NewVar = Example_NullWhenTrue(2, out var OutputStringNewVar2);

// Check if each of the test values are null based on the function return value.
// Then call a function that requires a non-null string, but only when the test values aren't null.

// The below function call should always run because the value will never be null.
if (IsNotNull_ShouldNotBeNull) {
    TestString(NotNullTest2);
}

// The below function call should never run as the value will always be null
if (IsNotNull_ShouldBeNull) {
    TestString(AlwaysNullTest2);
}
// Also occurs with new variables
if (IsNotNull_ShouldNotBeNull_NewVar) {
    TestString(OutputStringNewVar2);
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

// The below function call should always run because the value will never be null.
if (IsNull_ShouldNotBeNull) {
    TestString(NotNullTest);
}
// The below function call should never run as the value will always be null
if (IsNull_ShouldBeNull) {
    TestString(AlwaysNullTest);
}
// The below function call should never run because the value will never be null.
if (!IsNotNull_ShouldNotBeNull) {
    TestString(NotNullTest2);
}
// The below function call should always run as the value will always be null
if (!IsNotNull_ShouldBeNull) {
    TestString(AlwaysNullTest2);
}
// The below function call should never run because the value will never be null.
if (!ShouldNotBeNull_Struct) {
    TestInt(NotNullStructTest);
}
// The below function call should always run as the value will always be null
if (!ShouldBeNull_Struct) {
    TestInt(NotNullStructTest);
}
#endregion
