using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_4_DIS
{
    public class Edge: IComparable<Edge>
    {
        int vertex1;
        int vertex2;
        int weight;
        public Edge()
        {
            vertex1 = 0;
            vertex2 = 0;
            weight = 0;
        }
        public Edge(int vertex1, int vertex2, int weight)
        {
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
            this.weight = weight;
        }
        public int Vertex1
        {
            get { return vertex1; }
            set { vertex1 = value; }
        }
        public int Vertex2
        {
            get { return vertex2; }
            set { vertex2 = value; }
        }
        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public int CompareTo(Edge other)
        {
            return Weight.CompareTo(other.Weight);
        }
    }
}
