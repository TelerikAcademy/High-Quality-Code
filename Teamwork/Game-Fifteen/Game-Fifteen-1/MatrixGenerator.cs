using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteenProject
{
    static class MatrixGenerator
    {
        private const int HORIZONTAL_NEIGHBOUR_TILE = 1;
        private const int VERTICAL_NEIGHBOUR_TILE = 4;
        private const int MATRIX_SIZE = 4;
        private const int MINIMUM_CYCLES = 20;
        private const int MAXIMUM_CYCLES = 50;
        private static Random random;
        public static List<Tile> GenerateMatrix()
        {
            List<Tile> tiles = new List<Tile>();

            for (int index = 0; index < 15; index++)
            {
                String tileName = (index + 1).ToString();

                Tile tempTile = new Tile(tileName, index);
                tiles.Add(tempTile);


            }

            Tile emptyTile = new Tile(string.Empty, 15);
            tiles.Add(emptyTile);

            return tiles;
        }
        public static List<Tile> ShuffleMatrix(List<Tile> startingMatrix)
        {
            random = new Random();
            int cycleCount = random.Next(MINIMUM_CYCLES, MAXIMUM_CYCLES);
            List<Tile> resultMatrix = new List<Tile>();
            resultMatrix = startingMatrix;

            for (int index = 0; index < cycleCount; index++)
            {
                resultMatrix = MoveFreeTile(resultMatrix);
            }

            return resultMatrix;



        }
        private static List<Tile> MoveFreeTile(List<Tile> resultMatrix)
        {
            Tile freeTile = DetermineFreeTile(resultMatrix);

            List<Tile> neighbourTiles = new List<Tile>();

            foreach (Tile tile in resultMatrix)
            {


                neighbourTiles = GenerateNeighbourTilesList(freeTile, tile, neighbourTiles);
            }

            int switchedindexNumber = random.Next()%(neighbourTiles.Count());
            Tile targetTile = neighbourTiles[switchedindexNumber];

            int targetTilePosition = targetTile.Position;
            resultMatrix[targetTile.Position].Position = freeTile.Position;
            resultMatrix[freeTile.Position].Position = targetTilePosition;
            resultMatrix.Sort();

            return resultMatrix;
        }
        private static Tile DetermineFreeTile(List<Tile> resultMatrix)
        {



            Tile freeTile = new Tile();

            foreach (Tile tile in resultMatrix)
            {
                if (tile.Label == string.Empty)
                {
                    freeTile = tile;
                }
            }
            return freeTile;
        }

        private static List<Tile> GenerateNeighbourTilesList(Tile freeTile, Tile tile, List<Tile> neighbourTiles)
        {
            bool areValidNeighbourTiles = AreValidNeighbourTiles(freeTile, tile);
            if (areValidNeighbourTiles)
            {


                neighbourTiles.Add(tile);
            }
            return neighbourTiles;
        }
        private static bool AreValidNeighbourTiles(Tile freeTile, Tile tile)
        {
            int tilesDistance = freeTile.Position - tile.Position;
            int tilesAbsoluteDistance = Math.Abs(tilesDistance);
            bool isValidHorizontalNeighbour =
                ((tilesAbsoluteDistance == HORIZONTAL_NEIGHBOUR_TILE) && !(((tile.Position + 1) % MATRIX_SIZE == 1 && tilesDistance == -1) || ((tile.Position + 1) % MATRIX_SIZE == 0 && tilesDistance == 1)));
            bool isValidVerticalNeighbour = (tilesAbsoluteDistance == VERTICAL_NEIGHBOUR_TILE);
            bool validNeigbour = isValidHorizontalNeighbour || isValidVerticalNeighbour;

            return validNeigbour;
        }



    }
}
