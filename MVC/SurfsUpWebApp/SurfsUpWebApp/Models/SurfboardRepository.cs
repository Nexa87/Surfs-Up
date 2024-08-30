namespace SurfsUpWebApp.Models
{
    public class SurfboardRepository
    {
        public List<Surfboard> Surfboards { get; set; } = new List<Surfboard>();

        /// <summary>
        /// Adds the inputted Surfboard if possible & returns a bool stating whether the operation succeeded.
        /// </summary>
        /// <param name="surfboardToAdd"></param>
        /// <returns></returns>
        public bool Add_Surfboard (Surfboard surfboardToAdd)
        {
            bool wasAdded = false;

            if (Surfboards != null && Surfboards.Contains (surfboardToAdd) == false)
            {
                Surfboards.Add(surfboardToAdd);
                wasAdded = true;
            }

            return wasAdded;
        }

        /// <summary>
        /// Tries to get a given Surfboard from the list, via a boardName. Returns null if unsuccesful.
        /// </summary>
        /// <returns></returns>
        public Surfboard Get_Surfboard_ByBoardName (string boardName)
        {
            if (Surfboards != null)
            {
                for (int b = 0; b < Surfboards.Count; b++)
                {
                    if (Surfboards[b] != null && Surfboards[b].BoardName == boardName)
                        return Surfboards[b];
                }
            }

            return null;
        }

        /// <summary>
        /// Finds a surfboard via name & if found, updates its length.
        /// </summary>
        /// <param name="nameOfSurfboardToUpdate"></param>
        /// <param name="newLength"></param>
        /// <returns></returns>
        public bool Update_Surfboard_Length (string nameOfSurfboardToUpdate, float newLength)
        {
            bool updatedSuccesfully = false;

            Surfboard board = Get_Surfboard_ByBoardName(nameOfSurfboardToUpdate);
            if (board != null)
            {
                board.Length = newLength;
                updatedSuccesfully = true;
            }

            return updatedSuccesfully;
        }

        /// <summary>
        /// Finds a surfboard via name & if found, updates its width.
        /// </summary>
        /// <param name="nameOfSurfboardToUpdate"></param>
        /// <param name="newLength"></param>
        /// <returns></returns>
        public bool Update_Surfboard_Width(string nameOfSurfboardToUpdate, float newWidth)
        {
            bool updatedSuccesfully = false;

            Surfboard board = Get_Surfboard_ByBoardName(nameOfSurfboardToUpdate);
            if (board != null)
            {
                board.Width = newWidth;
                updatedSuccesfully = true;
            }

            return updatedSuccesfully;
        }

        /// <summary>
        /// Finds a surfboard via name & if found, updates its thickness.
        /// </summary>
        /// <param name="nameOfSurfboardToUpdate"></param>
        /// <param name="newLength"></param>
        /// <returns></returns>
        public bool Update_Surfboard_Thickness(string nameOfSurfboardToUpdate, float newThickness)
        {
            bool updatedSuccesfully = false;

            Surfboard board = Get_Surfboard_ByBoardName(nameOfSurfboardToUpdate);
            if (board != null)
            {
                board.Thickness = newThickness;
                updatedSuccesfully = true;
            }

            return updatedSuccesfully;
        }

        /// <summary>
        /// Finds a surfboard via name & if found, updates its volume.
        /// </summary>
        /// <param name="nameOfSurfboardToUpdate"></param>
        /// <param name="newLength"></param>
        /// <returns></returns>
        public bool Update_Surfboard_Volume(string nameOfSurfboardToUpdate, float newVolume)
        {
            bool updatedSuccesfully = false;

            Surfboard board = Get_Surfboard_ByBoardName(nameOfSurfboardToUpdate);
            if (board != null)
            {
                board.Volume = newVolume;
                updatedSuccesfully = true;
            }

            return updatedSuccesfully;
        }

        /// <summary>
        /// Finds a surfboard via name & if found, updates its price.
        /// </summary>
        /// <param name="nameOfSurfboardToUpdate"></param>
        /// <param name="newLength"></param>
        /// <returns></returns>
        public bool Update_Surfboard_Price(string nameOfSurfboardToUpdate, float newPrice)
        {
            bool updatedSuccesfully = false;

            Surfboard board = Get_Surfboard_ByBoardName(nameOfSurfboardToUpdate);
            if (board != null)
            {
                board.Price = newPrice;
                updatedSuccesfully = true;
            }

            return updatedSuccesfully;
        }

        /// <summary>
        /// Finds a surfboard via name & if found, updates its equipment ONLY BY ADDING 'newEquipment'.
        /// IMPORTANT: Don't prepend 'equipmentToAdd' with a comma, this happens automatically.
        /// NOTE: If you want to add multiple equipment, only add commas after the first, e.g. "newThing, newThing2, newThing3".
        /// If you want to OVERWRITE it, use Update_Surfboard_Equipment_ByOverwriting() instead!
        /// </summary>
        /// <param name="nameOfSurfboardToUpdate"></param>
        /// <param name="newLength"></param>
        /// <returns></returns>
        public bool Update_Surfboard_Equipment_OnlyAdding (string nameOfSurfboardToUpdate, string equipmentToAdd)
        {
            bool updatedSuccesfully = false;

            Surfboard board = Get_Surfboard_ByBoardName(nameOfSurfboardToUpdate);
            if (board != null)
            {
                board.Equipment = board.Equipment + $",{equipmentToAdd}";
                updatedSuccesfully = true;
            }

            return updatedSuccesfully;
        }

        /// <summary>
        /// Finds a surfboard via name & if found, updates its equipment BY OVERWRITING THE CURRENT with 'equipmentToOverwriteWith'.
        /// NOTE: If you want to only ADD additional equipment, use Update_Sorfboard_Equipment_OnlyAdding() instead!
        /// </summary>
        /// <param name="nameOfSurfboardToUpdate"></param>
        /// <param name="equipmentToOverwriteWith"></param>
        /// <returns></returns>
        public bool Update_Surfboard_Equipment_ByOverwriting (string nameOfSurfboardToUpdate, string equipmentToOverwriteWith)
        {
            bool updatedSuccesfully = false;

            Surfboard board = Get_Surfboard_ByBoardName(nameOfSurfboardToUpdate);
            if (board != null)
            {
                board.Equipment = equipmentToOverwriteWith;
                updatedSuccesfully = true;
            }

            return updatedSuccesfully;
        }

        /// <summary>
        /// Removes the inputted surfboard, if it exists in the list & returns a bool stating whether the operation succeeded.
        /// </summary>
        /// <param name="surfboardToRemove"></param>
        /// <returns></returns>
        public bool Remove_Surfboard (Surfboard surfboardToRemove)
        {
            bool wasRemoved = false;

            if (Surfboards != null && Surfboards.Contains (surfboardToRemove))
            {
                Surfboards.Remove(surfboardToRemove);
                wasRemoved = true;
            }

            return wasRemoved;
        }


    }
}