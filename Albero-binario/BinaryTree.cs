using Albero_binario;
using System;
using System.Collections.Generic;
using System.Text;

internal class BinaryTree<T>
{
    private Node<T> radice;

    public BinaryTree()
    {
        radice = null;
    }

    //numero totale di nodi
    public int NumNodi()
    {
        return CountNodes(radice); //conteggio ricorsivo a partire dalla radice
    }

    //conteggio ricorsivo dei nodi
    private int CountNodes(Node<T> node)
    {
        if (node == null)
        {
            return 0; //foglia, non contribuisce al conteggio
        }
        //1 per il nodo corrente + nodi del sottoalbero sinistro + nodi del sottoalbero destro
        return 1 + CountNodes(node.Left) + CountNodes(node.Right);
    }

    //grado del nodo (numero di figli)
    public int Grado(Node<T> node)
    {
        int g = 0;
        if (node.Left != null)
        {
            g++; //incrementa se esiste figlio sinistro
        }
        if (node.Right != null)
        {
            g++; //incrementa se esiste figlio destro
        }
        return g;
    }

    //ritorna il padre del nodo
    public Node<T> Padre(Node<T> node)
    {
        if (node == null || node == radice)
        {
            return null; //radice o nodo nullo non ha padre
        }
        return CercaParent(radice, node); //ricerca ricorsiva del genitore
    }

    //ricerca ricorsiva del genitore
    private Node<T> CercaParent(Node<T> current, Node<T> target)
    {
        if (current == null)
        {
            return null; //raggiunta foglia senza trovare il nodo
        }

        if (current.Left == target || current.Right == target)
        {
            return current; //il nodo corrente è il genitore
        }

        Node<T> leftResult = CercaParent(current.Left, target);
        //ricorsione sul sottoalbero sinistro, se trovato ritorna subito il genitore
        if (leftResult != null)
        {
            return leftResult;
        }

        //altrimenti ricorsione sul sottoalbero destro
        return CercaParent(current.Right, target);
    }

    //ritorna la lista dei figli del nodo
    public List<Node<T>> Figli(Node<T> node)
    {
        List<Node<T>> figli = new List<Node<T>>();
        if (node.Left != null)
        {
            figli.Add(node.Left); //aggiunge figlio sinistro
        }
        if (node.Right != null)
        {
            figli.Add(node.Right); //aggiunge figlio destro
        }
        return figli;
    }

    //aggiunge un nuovo nodo come figlio
    public Node<T> AggiungiNodo(Node<T> u, T value)
    {
        Node<T> nuovo = new Node<T>(value);

        if (u.Left == null)
        {
            u.Left = nuovo; //inserisce a sinistra se libero
        }
        else if (u.Right == null)
        {
            u.Right = nuovo; //altrimenti a destra se libero
        }
        else
        {
            throw new Exception("Nodo ha già due figli"); //errore se pieno
        }

        return nuovo;
    }

    //aggiunge un sottoalbero come figlio
    public void AggiungiSottoalbero(BinaryTree<T> a, Node<T> u)
    {
        if (a == null || a.radice == null)
        {
            throw new Exception("Sottoalbero vuoto");
        }

        if (u.Left == null)
        {
            u.Left = a.radice; //collega la radice del sottoalbero a sinistra
        }
        else if (u.Right == null)
        {
            u.Right = a.radice; //collega la radice del sottoalbero a destra
        }
        else
        {
            throw new Exception("Nodo ha già due figli");
        }
    }

    //rimuove un sottoalbero e lo restituisce
    public BinaryTree<T> RimuoviSottoalbero(Node<T> v)
    {
        if (v == null)
        {
            throw new Exception("Nodo nullo");
        }

        Node<T> padre = Padre(v);
        if (padre != null)
        {
            if (padre.Left == v)
            {
                padre.Left = null; //stacca il figlio sinistro
            }
            else if (padre.Right == v)
            {
                padre.Right = null; //stacca il figlio destro
            }
        }
        else
        {
            radice = null; //v era radice, l'albero principale diventa vuoto
        }

        BinaryTree<T> newTree = new BinaryTree<T>();
        newTree.radice = v; //v diventa radice del nuovo sottoalbero
        return newTree;
    }

    //imposta la radice
    public void SetRadice(T value)
    {
        if (radice != null)
        {
            throw new Exception("Radice già esistente");
        }
        radice = new Node<T>(value);
    }

    //ritorna la radice
    public Node<T> GetRadice()
    {
        return radice;
    }
}