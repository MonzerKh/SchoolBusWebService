using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Models
{
    public class Chromosome
    {
        public Chromosome(LocationPeer rootNode) { RootNode = rootNode; this.Childrens = new List<Chromosome>(); }
        public Chromosome(LocationPeer rootNode, Chromosome parent) : this(rootNode)
        {
            this.Parent = parent;
            this.Distince = Paths.CalcuateDistance(parent.RootNode, rootNode);
        }

        public void SetDeafultStatus()
        {
            IsVisited = false;
            Childrens.ForEach(r => r.SetDeafultStatus());
        }

        public Chromosome(LocationPeer rootNode, Chromosome parent, List<Chromosome> childs) : this(rootNode, parent) => this.Childrens = childs;

        public bool IsVisited { get; set; }

        public LocationPeer RootNode { get; set; }
        public Chromosome Parent { get; set; }
        public List<Chromosome> Childrens { get; set; }
        public double Distince { get; set; }

        public void CreateRoadsMap(List<LocationPeer> Peers)
        {
            foreach (var item in Peers)
            {
                var Childs = Peers.ToList();
                Childs.Remove(item);


                var ChildNode = new Chromosome(item, this);
                ChildNode.CreateRoadsMap(Childs);
               this.Childrens.Add(ChildNode);
            }
        }
    }
}
