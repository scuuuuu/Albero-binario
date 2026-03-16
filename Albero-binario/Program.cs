using System;
using System.Collections.Generic;
using Albero_binario;

class Program
{
    static void Main(string[] args)
    {
        //crea un albero di interi
        BinaryTree<int> albero = new BinaryTree<int>();
        //imposta la radice
        albero.SetRadice(10);
        Node<int> radice = albero.GetRadice();
        //aggiungi nodi
        Node<int> nodo1 = albero.AggiungiNodo(radice, 5);  //figlio sinistro
        Node<int> nodo2 = albero.AggiungiNodo(radice, 15); //figlio destro
        //aggiungi sottoalbero
        BinaryTree<int> sottoalbero = new BinaryTree<int>();
        sottoalbero.SetRadice(20);
        sottoalbero.AggiungiNodo(sottoalbero.GetRadice(), 25);
        albero.AggiungiSottoalbero(sottoalbero, nodo1); //collega sottoalbero a nodo1
        Console.WriteLine("numero totale di nodi: " + albero.NumNodi());
        Console.WriteLine("grado della radice: " + albero.Grado(radice));
        Console.WriteLine("padre di nodo 25: " + albero.Padre(sottoalbero.GetRadice()).Value);
        //rimuovi un sottoalbero
        BinaryTree<int> staccato = albero.RimuoviSottoalbero(nodo1);
        Console.WriteLine("numero nodi nell'albero principale dopo rimozione: " + albero.NumNodi());
        Console.WriteLine("numero nodi nel sottoalbero staccato: " + staccato.NumNodi());
    }
}