using System.Collections.Generic;
using Common.Database;
using Common.Logging;
using Node.Database;
using Node.Inventory;
using Node.Inventory.Items.Types;
using Node.Network;
using PythonTypes.Types.Database;
using PythonTypes.Types.Exceptions;
using PythonTypes.Types.Primitives;
using SimpleInjector;

namespace Node.Services.Corporations
{
    public class corpRegistry : BoundService
    {
        private Corporation mCorporation = null;
        private int mIsMaster = 0;

        public Corporation Corporation => this.mCorporation;
        public int IsMaster => this.mIsMaster;

        private CorporationDB DB { get; }
        private ItemManager ItemManager { get; }
        public corpRegistry(CorporationDB db, ItemManager itemManager, BoundServiceManager manager) : base(manager)
        {
            this.DB = db;
            this.ItemManager = itemManager;
        }

        protected corpRegistry(CorporationDB db, ItemManager itemManager, Corporation corp, int isMaster, BoundServiceManager manager) : base (manager)
        {
            this.DB = db;
            this.ItemManager = itemManager;
            this.mCorporation = corp;
            this.mIsMaster = isMaster;
        }

        protected override BoundService CreateBoundInstance(PyDataType objectData)
        {
            PyTuple data = objectData as PyTuple;
            
            /*
             * objectData[0] => corporationID
             * objectData[1] => isMaster
             */
            Corporation corp = this.ItemManager.LoadItem(data[0] as PyInteger) as Corporation;
            
            return new corpRegistry(this.DB, this.ItemManager, corp, data[1] as PyInteger, this.BoundServiceManager);
        }

        public PyDataType GetEveOwners(CallInformation call)
        {
            // this call seems to be getting all the members of the given corporationID
            return this.DB.GetEveOwners(this.Corporation.ID);
        }

        public PyDataType GetCorporation(CallInformation call)
        {
            return this.Corporation.GetCorporationInfoRow();
        }

        public PyDataType GetSharesByShareholder(PyBool corpShares, CallInformation call)
        {
            if (call.Client.CharacterID == null)
                throw new UserError("NoCharacterSelected");
            
            return this.DB.GetSharesByShareholder((int) call.Client.CharacterID);
        }

        public PyDataType GetMember(PyInteger memberID, CallInformation call)
        {
            return this.DB.GetMember(memberID, call.Client.CorporationID);
        }

        public PyDataType GetMembers(CallInformation call)
        {
            // generate the sparse rowset
            SparseRowsetHeader rowsetHeader = this.DB.GetMembersSparseRowset(call.Client.CorporationID);

            PyDictionary dict = new PyDictionary
            {
                ["realRowCount"] = rowsetHeader.Count
            };
            
            // create a service for handling it's calls
            MembersSparseRowsetService svc =
                new MembersSparseRowsetService(this.Corporation, this.DB, rowsetHeader, this.BoundServiceManager);

            rowsetHeader.BoundObjectIdentifier = svc.MachoBindObject(dict, call.Client);
            
            // finally return the data
            return rowsetHeader;
        }

        public PyDataType GetOffices(CallInformation call)
        {
            // generate the sparse rowset
            SparseRowsetHeader rowsetHeader = this.DB.GetOfficesSparseRowset(call.Client.CorporationID);

            PyDictionary dict = new PyDictionary
            {
                ["realRowCount"] = rowsetHeader.Count
            };
            
            // create a service for handling it's calls
            OfficesSparseRowsetService svc =
                new OfficesSparseRowsetService(this.Corporation, this.DB, rowsetHeader, this.BoundServiceManager);

            rowsetHeader.BoundObjectIdentifier = svc.MachoBindObject(dict, call.Client);
            
            // finally return the data
            return rowsetHeader;
        }

        public PyDataType GetRoleGroups(CallInformation call)
        {
            return this.DB.GetRoleGroups();
        }

        public PyDataType GetRoles(CallInformation call)
        {
            return this.DB.GetRoles();
        }

        public PyDataType GetDivisions(CallInformation call)
        {
            return this.DB.GetDivisions();
        }

        public PyDataType GetTitles(CallInformation call)
        {
            // check if the corp is NPC and return placeholder data from the crpTitlesTemplate
            if (ItemManager.IsNPCCorporationID(call.Client.CorporationID) == true)
            {
                return this.DB.GetTitlesTemplate();
            }
            else
            {
                return this.DB.GetTitles(call.Client.CorporationID);                
            }
        }

        public PyDataType GetMemberTrackingInfo(PyInteger characterID, CallInformation call)
        {
            // TODO: RETURN FULL TRACKING INFO, ONLY DIRECTORS ARE ALLOWED TO DO SO!
            return null;
        }

        public PyDataType GetMemberTrackingInfoSimple(CallInformation call)
        {
            return this.DB.GetMemberTrackingInfoSimple(call.Client.CorporationID);
        }

        public PyDataType GetInfoWindowDataForChar(PyInteger characterID, CallInformation call)
        {
            int titleMask = this.DB.GetTitleMaskForCharacter(characterID, call.Client.CorporationID);
            Dictionary<int, string> titles = this.DB.GetTitlesNames(call.Client.CorporationID);
            PyDictionary dictForKeyVal = new PyDictionary();

            int number = 0;

            foreach (KeyValuePair<int, string> title in titles)
                dictForKeyVal["title" + (++number)] = title.Value;
            
            // we're supposed to be from the same corp, so add the extra information manually
            // TODO: TEST WITH USERS FROM OTHER CORPS
            dictForKeyVal["corpID"] = call.Client.CorporationID;
            dictForKeyVal["allianceID"] = call.Client.AllianceID;
            dictForKeyVal["title"] = "TITLE HERE";

            return KeyVal.FromDictionary(dictForKeyVal);
        }
    }
}