
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class Usuario {

        private int codUsuario;
        private string login;
        private string senha;
        private string nivel;
        public Usuario() {
        }
        public int GetCodUsuario() {return this.codUsuario;}
        public string GetLogin() {return this.login;}
        public string GetSenha(){return this.senha;}
        public string GetNivel() {return this.nivel;}

    }
}