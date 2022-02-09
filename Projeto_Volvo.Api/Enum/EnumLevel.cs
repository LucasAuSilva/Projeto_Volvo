using System.ComponentModel;

namespace Projeto_Volvo.Api.Enum
{
    public enum EnumLevel
    {
        [Description("funcionario")]
        Funcionario = 1,
        [Description("cliente")]
        Cliente = 2,
        [Description("gerente")]
        Gerente = 3
    }
}
