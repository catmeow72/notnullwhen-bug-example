using System.Diagnostics.CodeAnalysis;
public static class ExampleFunctions {
    /// <Summary>
    /// Either returns true and sets the output to "Meow!", or returns false and sets the output to null.
    /// Note the NotNullWhen attribute. This should tell the compiler that the value is not null when the function returns <c>true</c>
    /// </Summary>
    /// <Param name="ExampleInt">If even, the output will not be null. Otherwise, it will be.</Param>
    /// <Param name="OutputString">The string to set.</Param>
    /// <Returns><c>true</c> if the value is not null, <c>false</c> otherwise.</Returns>
    public static bool Example_NullWhenTrue(int ExampleInt, [NotNullWhen(false)] out string? OutputString) {
        if (ExampleInt % 2 == 0) {
            OutputString = "Meow!";
            return false;
        } else {
            OutputString = null;
            return true;
        }
    }
    /// <Summary>
    /// Either returns true and sets the output to "Meow!", or returns false and sets the output to null.
    /// Note the NotNullWhen attribute. This should tell the compiler that the value is not null when the function returns <c>false</c>
    /// </Summary>
    /// <Param name="ExampleInt">If even, the output will not be null. Otherwise, it will be.</Param>
    /// <Param name="OutputString">The string to set.</Param>
    /// <Returns><c>true</c> if the value is null, <c>false</c> otherwise.</Returns>
    public static bool Example_NullWhenFalse(int ExampleInt, [NotNullWhen(true)] out string? OutputString) {
        if (ExampleInt % 2 == 0) {
            OutputString = "Meow!";
            return true;
        } else {
            OutputString = null;
            return false;
        }
    }
    
    /// <Summary>
    /// Either returns true and sets the output to -1, or returns false and sets the output to null.
    /// Note the NotNullWhen attribute. This should tell the compiler that the value is not null when the function returns <c>false</c>
    /// </Summary>
    /// <Param name="ExampleInt">If even, the output will not be null. Otherwise, it will be.</Param>
    /// <Param name="OutputString">The string to set.</Param>
    /// <Returns><c>true</c> if the value is null, <c>false</c> otherwise.</Returns>
    public static bool Example_Struct(int ExampleInt, [NotNullWhen(true)] out int? OutputInt) {
        if (ExampleInt % 2 == 0) {
            OutputInt = -1;
            return true;
        } else {
            OutputInt = null;
            return false;
        }
    }
}