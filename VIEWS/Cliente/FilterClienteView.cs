﻿using CONTROLLER;
using VIEWS.Cliente.Relatorio;
using System;
using System.Windows.Forms;

namespace VIEWS
{
    public partial class FilterClienteView : Form
    {
        public FilterClienteView()
        {
            InitializeComponent();

            dtGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ControllerCliente controllerCliente = new ControllerCliente();
            var clientes = controllerCliente.Read();
            Dados dados = new Dados();

            if (clientes.Count > 0)
            {
                foreach (var idx in clientes)
                {
                    dados.Clientes.Rows.Add(idx.GetCnpj(), idx.GetNome(), idx.GetTelefone(), idx.GetRua(), idx.GetNumero(), idx.GetBairro(), idx.GetCidade(), idx.GetSiglaEs());
                }
                dtGrid.DataSource = dados.Clientes;
            }
            else
            {
                dtGrid.Enabled = false;
            }
        }
        private void Filter(object sender, EventArgs e)
        {
            ControllerCliente controllerCliente = new ControllerCliente();
            Dados dados = new Dados();
            decimal? cnpj = null;
            if(txtCnpj.Text != string.Empty)
            {
            cnpj = decimal.Parse(txtCnpj.Text);
            }
            var retorno = controllerCliente.Filter(cnpj, txtNome.Text);
            if(retorno.Count > 0)
            {
                foreach (var idx in retorno)
                {
                dados.Clientes.Rows.Add(idx.GetCnpj(), idx.GetNome(), idx.GetTelefone(), idx.GetRua(), idx.GetNumero(), idx.GetBairro(), idx.GetCidade(), idx.GetSiglaEs());
                }
            }

            dtGrid.DataSource = dados.Clientes;

        }
        private void Read(object sender, EventArgs e)
        {
            ControllerCliente controllerCliente = new ControllerCliente();
            var clientes = controllerCliente.Read();
            Dados dados = new Dados();

            if (clientes.Count > 0)
            {
                foreach (var idx in clientes)
                {
                    dados.Clientes.Rows.Add(idx.GetCnpj(), idx.GetNome(), idx.GetTelefone(), idx.GetRua(), idx.GetNumero(), idx.GetBairro(), idx.GetCidade(), idx.GetSiglaEs());
                }
                dtGrid.DataSource = dados.Clientes;
            }
            else
            {
                dtGrid.Enabled = false;
            }
        }
    }
}
