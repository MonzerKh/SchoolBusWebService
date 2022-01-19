using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Models
{
    public class TSP_Tree
    {
        public TSP_Tree(LocationPeer rootTree)
        {
            RootTree = new Chromosome(rootTree);
        }

        public Chromosome RootTree { get; set; }
       
        public void ResetTreeStatus()
        {
            RootTree.SetDeafultStatus();
        }
        public void CreateRoadsMap(List<LocationPeer> Peers)
        {
            List<Task> TreeTask = new List<Task>();
            foreach (var item in Peers)
            {
                TreeTask.Add(Task.Factory.StartNew(() =>
                {
                    var Childs = Peers.ToList();
                    Childs.Remove(item);

                    var ChildNode = new Chromosome(item, RootTree);
                    ChildNode.CreateRoadsMap(Childs);
                    RootTree.Childrens.Add(ChildNode);
                }));
            }
            Task.WaitAll(TreeTask.ToArray());
        }


        public List<LocationPeer> FindShortPathTree()
        {
            if (RootTree == null) return null;

            ResetTreeStatus();
            
            var Index = RootTree;
            List<List<Chromosome>> Paths = new List<List<Chromosome>>();
            Paths.Add(new List<Chromosome>() {RootTree});
            while (Index.Childrens.Count > 0)
            {
                var OldPaths = Paths.ToList();
                Paths.Clear();
                Index.IsVisited = true;

                foreach (var child in Index.Childrens)
                {
                    foreach (var soluation in OldPaths)
                    {
                        var NewSolution = soluation.ToList();
                        NewSolution.Add(child);
                        Paths.Add(NewSolution);
                    }
                }

            }
            int ShortPathIndex = -1;
            double Total = double.MaxValue;
            for (int i = 0; i < Paths.Count; i++)
            {
                var PathTotal = Paths[i].Sum(r => r.Distince);
                if (PathTotal < Total)
                {
                    ShortPathIndex = i;
                    Total = PathTotal;
                }
            }

            List<LocationPeer> ShortPath = new List<LocationPeer>();
            foreach (var item in Paths[ShortPathIndex])
            {
                ShortPath.Add(item.RootNode);
            }
            return ShortPath;
        }

        public List<LocationPeer> FindShortPathTree2()
        {
            if (RootTree == null) return null;
            var Path = preOrder(RootTree);
            List<LocationPeer> ShortRoad = new List<LocationPeer>();
            Path.ForEach(r => ShortRoad.Add(r.RootNode));
            return ShortRoad;
        }

        public List<Chromosome> preOrder(Chromosome node)
        {
            if (node.Childrens == null || node.Childrens.Count == 0) return new List<Chromosome>() { node };

            if (node.Childrens.Count() == 1)
            {
                var List = preOrder(node.Childrens.FirstOrDefault());
                List.Add(node);
                return List;
            }

            List<Chromosome> ResultPath = null;
         
            foreach (var item in node.Childrens)
            {
                var distance = preOrder(item);
                distance.Add(node);
                if ( ResultPath == null)
                    ResultPath = distance;
               
                if (distance.Sum(r=>r.Distince) < ResultPath.Sum(r=>r.Distince))
                    ResultPath = distance;
            }
            //ResultPath.Add(this.RootTree);
            return ResultPath;
        }
    }


}
