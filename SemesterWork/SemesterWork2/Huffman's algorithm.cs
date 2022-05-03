using System.Xml;

namespace SemesterWork;

public class Huffman_s_algorithm
{
    public int counter;
    public static string HuffmanAlgorithm(List<TreeNode<string>> Data, List<int> weight, string s)
    {
        var result = "";
        TreeNode<string> Tree;
        var CopyData = new List<string>(); foreach (var i in Data) {CopyData.Add(i.Data); }
        
        while (weight.Count > 1)
        {
            var node = new TreeNode<string>("-");
            node.Left = Data[0]; node.Right = Data[1];
            var sum = weight[0] + weight[1];
            
            Data.RemoveAt(0); Data.RemoveAt(0);
            weight.RemoveAt(0); weight.RemoveAt(0);
            
            if (weight.Contains(sum))
            {
                weight.Insert(weight.IndexOf(sum), sum);
                Data.Insert(weight.IndexOf(sum), node);
            }
            else
            {
                AddIndex(ref weight, sum);
                Data.Insert(weight.IndexOf(sum), node);
            }
        }

        Tree = Data[0];
        var Code = new Dictionary<string, string>();
        foreach (var el in CopyData)
        {
            var resultCode = "";
            Search(el, Tree, resultCode);
            Console.WriteLine($"{el}, {Code[el]}");
        }

        foreach (var el in s)
        {
            result += Code[el.ToString()];
        }

        return result;
        
        void Search(string el, TreeNode<string> node, string res)
        {
            if (node.Left != null && node.Left.Data == el)
            {
                Code.Add(el, res + "0");
            }
            else if (node.Right != null && node.Right.Data == el)
            {
                Code.Add(el, res + "1");
            }

            else
            {
                if (node.Left != null)
                {
                    Search(el, node.Left, res + "0");
                }
                if (node.Right != null)
                {
                    Search(el, node.Right, res + "1");
                }

            }
        }
    }
    
    static void AddIndex(ref List<int> list, int weight)
    {
        var index = 0;
        foreach (var el in list)
        {
            if (el < weight)
            {
                index += 1;
            }
            else {list.Insert(index, weight); break;}
        }
        if (!list.Contains(weight)) {list.Insert(index, weight);}
    }
    
}
