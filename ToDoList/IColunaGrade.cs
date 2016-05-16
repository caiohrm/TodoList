using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoList
{
    public interface IColunaGrade
    {
        string Identificador
        { get; set; }

        string Titulo
        { get; set; }

        string Descricao
        { get; set; }

        bool EhInterno
        { get; set; }

        bool EhRequerido
        { get; set; }

        bool EhVisivel
        { get; set; }

        string Vinculo
        { get; set; }

        bool IsKey
        { get; set; }

        int Tamanho
        { get; set; }

        Type TipoDado
        { get; set; }

    }
}
