using SistemaCadastro.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCadastro.Domain.Utils;

public static class Validadores
{
    public static TipoDocumentoEnum IdentificarDocumento(string documento)
    {
        string numeros = new string(documento.Where(char.IsDigit).ToArray());

        if (numeros.Length == 11)
            return TipoDocumentoEnum.Cpf;
        else if (numeros.Length == 14)
            return TipoDocumentoEnum.Cnpj;
        else
            return 0;
    }
}
