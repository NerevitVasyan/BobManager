using BobManager.Dto.DtoResults;
using System;
using System.Collections.Generic;

namespace BobManager.Helpers.Managers
{
    /// <summary>
    /// Its class which contain decriptions to diffrent client errors
    /// *client error - its error which happened by client actions 
    /// </summary>
    /// Example using: 
    ///     register in startup file error
    ///         Example: clientErrManager.AddError(203/*Error ID*/, "SOME"/*ErrorDecription*/);
    ///     And if in controoler errr yo can 
    ///         return clientErrManager.MapErrorIDToResultDto(203);
    ///         
    public class ClientErrorManager {

        Dictionary<uint, string> descriptions = new Dictionary<uint, string>();

        public ClientErrorManager() {
            descriptions.Add(0, "Incorrect error indefier");
        }

        public bool AddError(uint id, string decription) {
            return descriptions.TryAdd(id, decription ?? throw new ArgumentNullException("decription"));
        }

        public void AddRangeErrors(Dictionary<uint, string> descriptions) {
            foreach (var item in descriptions ?? throw new ArgumentNullException("descriptions"))
                AddError(item.Key, item.Value);
        }

        public string GetErrorDecriptionByID(uint ID)
        {
            string description = null;
            descriptions.TryGetValue(ID, out description);
            return description;
        }

        public string GetErrorDecriptionByIDSave(uint ID)
        {
            var description = GetErrorDecriptionByID(ID);
            return description == null ? descriptions[0] : description;
        }

        public ResultDto MapErrorIDToResultDto(uint ID)
        {
            return new ErrorResultDto {
                ErrorID = ID, IsSuccessful = false,
                Message = GetErrorDecriptionByIDSave(ID)
            };
        }

        public ResultDto MapErrorIDToResultDto<T>(uint ID, T additionalInfo)
        {
            return new ErrorResultDto<T> {
                ErrorID = ID, IsSuccessful = false,
                Message = GetErrorDecriptionByIDSave(ID),
                AddtionalInfo = additionalInfo
            };
        }
    }
}