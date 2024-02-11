using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Shun_Grid_System
{
    [Serializable]
    public abstract class BaseGridCell2D<TItem>
    {
        [Header("Base")]
        public readonly List<BaseGridCell2D<TItem>> InDegreeCells = new(), OutDegreeCells = new();
        private readonly Dictionary<BaseGridCell2D<TItem> ,double> _outDegreeAdjacentCellCosts = new();
        public int XIndex, YIndex;
        public TItem Item;
        public bool IsObstacle = false;

        [Header("Pathfinding Debug")] 
        public BaseGridCell2D<TItem> ParentXZCell2D = null; 
        public double FCost;
        public double HCost;
        public double GCost;


        protected BaseGridCell2D(int xIndex, int yIndex, TItem item = default)
        {
            XIndex = xIndex;
            YIndex = yIndex;
            Item = item;
        }

        public void SetDirectionalAdjacencyCell(BaseGridCell2D<TItem>[] adjacentRawCells, double [] adjacentCellCost = null)
        {
            foreach (var adjacentCell in adjacentRawCells)
            {
                SetDirectionalAdjacencyCell(adjacentCell);
            }
        }
    
        public void SetDirectionalAdjacencyCell(BaseGridCell2D<TItem> adjacentCell, double adjacentCellCost = 0)
        {
            if (adjacentCell != null && !OutDegreeCells.Contains(adjacentCell) && !adjacentCell.InDegreeCells.Contains(this))
            {
                OutDegreeCells.Add(adjacentCell);
                adjacentCell.InDegreeCells.Add(this);

                _outDegreeAdjacentCellCosts[adjacentCell] = adjacentCellCost;
                
            }
        }

        public void RemoveAdjacency(BaseGridCell2D<TItem>[] adjacentRawCells)
        {
            foreach (var adjacentCell in adjacentRawCells)
            {
                RemoveAdjacency(adjacentCell);
            }
        }
    
        public void RemoveAdjacency(BaseGridCell2D<TItem> adjacentCell)
        {
            if (!InDegreeCells.Contains(adjacentCell)) return;
            
            InDegreeCells.Remove(adjacentCell);
            _outDegreeAdjacentCellCosts.Remove(adjacentCell);
        }

        public double GetAdditionalOutDegreeAdjacentCellCost(BaseGridCell2D<TItem> adjacentCell)
        {
            return OutDegreeCells.Contains(adjacentCell)? _outDegreeAdjacentCellCosts[adjacentCell] : 0;
        }
    }
}
