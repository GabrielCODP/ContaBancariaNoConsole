using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ContaBancaria.Enums
{
    enum TipoDaConta : int
    {
        //[Display(Name = "Pessoa Fisica")]
        PessoaFisica = 1,

        //[Display(Name = "Pessoa Juridica")]
        PessoaJuridica = 2
    }
}
