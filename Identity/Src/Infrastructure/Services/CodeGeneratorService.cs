using Identity.Src.Domain.Common.contracts;
using shortid;
using shortid.Configuration;
namespace Identity.Src.Infrastructure.Services;

public class CodeGeneratorService : ICodeGeneratorService
{
    private readonly GenerationOptions options;

    public CodeGeneratorService(int length = 4)
    {
        options = new GenerationOptions(useSpecialCharacters: false, length: length);
    }

    public string generate()
    {
        return ShortId.Generate(this.options);
    }
}

