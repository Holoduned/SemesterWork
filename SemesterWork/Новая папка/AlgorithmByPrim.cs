using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterWork
{
    public struct Edge
    {
        public int vertex1, vertex2;
        public int weight;

        public Edge(int v1, int v2, int Weight)
        {
            vertex1 = v1;
            vertex2 = v2;
            weight = Weight;
        }
    }
    public class AlgorithmByPrim
    {
        public static List<int> algorithmByPrim(List<Edge> E)
        {
            List<int> result = new();
            int counter = 0;
            
            List<Edge> notUsedEdges = new(E);
            //notUsedEdges = notUsedEdges.OrderBy(p => p.weight).ToList();
            List<int> UsedVertex = new();
            List<int> notUsedVertex = new();
            List<Edge> MST = new();

            for (int i = 0; i < notUsedEdges.Count; i++)
            {
                notUsedVertex.Add(notUsedEdges[i].vertex1);
                notUsedVertex.Add(notUsedEdges[i].vertex2);
            }
            notUsedVertex = notUsedVertex.Distinct().ToList();

            Random rand = new Random();
            UsedVertex.Add(rand.Next(1, notUsedVertex.Count + 1));
            notUsedVertex.Remove(UsedVertex[0]);

            while (notUsedVertex.Count > 0)
            {
                int minEdge = -1;
                for (int i = 0; i < notUsedEdges.Count; i++)
                {
                    if ((UsedVertex.IndexOf(notUsedEdges[i].vertex1) != -1) && (notUsedVertex.IndexOf(notUsedEdges[i].vertex2) != -1) ||
                        (UsedVertex.IndexOf(notUsedEdges[i].vertex2) != -1) && (notUsedVertex.IndexOf(notUsedEdges[i].vertex1) != -1))
                    {
                        if (minEdge != -1)
                        {
                            if (notUsedEdges[i].weight < notUsedEdges[minEdge].weight)
                                minEdge = i;
                        }
                        else
                            minEdge = i;
                    }

                    counter++;
                }

                if (minEdge == -1)
                {
                    result.Add(-1);
                    result.Add(counter);
                    return result;
                }

                if (UsedVertex.IndexOf(notUsedEdges[minEdge].vertex1) != -1)
                {
                    UsedVertex.Add(notUsedEdges[minEdge].vertex2);
                    notUsedVertex.Remove(notUsedEdges[minEdge].vertex2);
                }
                else
                {
                    UsedVertex.Add(notUsedEdges[minEdge].vertex1);
                    notUsedVertex.Remove(notUsedEdges[minEdge].vertex1);
                }

                MST.Add(notUsedEdges[minEdge]);
                notUsedEdges.RemoveAt(minEdge);
            }

            result.Add(MST.Select(x => x.weight).Sum());
            result.Add(counter);
            return result;

        }
    }
}
