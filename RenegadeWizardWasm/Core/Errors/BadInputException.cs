namespace RenegadeWizardWasm.Core.Errors;

public class BadInputException(string message) : ArgumentException(message);