using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static кальякулятор.Form1;

namespace кальякулятор
{
    public class TreeNode
    {
        public decimal? Value; // численное значение
        public Operator? oper; // операция
        public TreeNode Left; // левое поддерево
        public TreeNode Right; // правое поддерево
    }

    public class Tree
    {
        public TreeNode Node; // экземпляр класса "элемент дерева"
    
        // прямой обход (CLR - center, left, right)
        public decimal CLR(TreeNode node)
        {
            if (node != null)
            {
                if (node.oper != null)
                {
                    switch (node.oper)
                    {
                        case Operator.scit: return CLR(node.Left) + CLR(node.Right);
                        case Operator.odcit: return CLR(node.Left) - CLR(node.Right);
                        case Operator.nasob: return CLR(node.Left) * CLR(node.Right);
                        case Operator.del: return CLR(node.Left) / CLR(node.Right);
                    }
                }
                else
                {
                    return (decimal)node.Value;
                }
            }

            return 0;
        }
    }

}
