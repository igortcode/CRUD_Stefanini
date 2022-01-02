using Business.Entities;
using System;
using System.Collections.Generic;

namespace Application.ViewModel
{
    public class PessoaViewModel
    {
        public Guid IdPessoa { get; set; }
        public string Nome { get; set; }
        //public ICollection<PersonPhone> Phones { get; set; }
        public List<ContatoViewModel> Contatos { get; set; }
    }
}
