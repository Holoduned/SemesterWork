namespace SemesterWork;

public class DataManager
{
    public Dictionary<string, int> dictionary = new Dictionary<string, int>();
    public void CreateDictionary(string s)
    {
        foreach (var elem in s)
        {
            var el = elem.ToString();
            if (dictionary.ContainsKey(el))
            {
                dictionary[el] += 1;
            }
            else
            {
                dictionary.Add(el, 1);
            }
        }
        dictionary = dictionary.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
    }
    public static List<TreeNode<string>> DataList(Dictionary<string, int> Data)
    {
        var datalist = new List<TreeNode<string>>();
        foreach (var el in Data)
        {
            datalist.Add(new TreeNode<string>(el.Key));
        }
        
        return datalist;
    }
    
    public static List<int> WeightList(Dictionary<string, int> Data)
    {
        var datalist = new List<int>();
        foreach (var el in Data)
        {
            datalist.Add(el.Value);
        }
        
        return datalist;
    }
}