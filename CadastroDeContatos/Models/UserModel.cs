﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CadastroDeContatos.Enums;
using CadastroDeContatos.Helper;

namespace CadastroDeContatos.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Insira o nome do usuário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Insira o email do usuário")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Insira o login do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Insira o perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }
        [Required(ErrorMessage = "Insira a senha do usuário")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public virtual List<ContatoModel> Contatos { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }
        public string GerarSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }

        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }
    }
}
