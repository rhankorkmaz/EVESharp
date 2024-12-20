namespace EVESharp.Database.Inventory.Attributes;

public class AttributeType
{
    public int       ID                   { get; }
    public string    Name                 { get; }
    public int       Category             { get; }
    public string    Description          { get; }
    public AttributeType MaxAttribute         { get; } // TODO: REFERENCE TO ANOTHER ATTRIBUTE INFO
    public int       AttributeIDX         { get; }
    public int       GraphicID            { get; }
    public int       ChargeRechargeTimeID { get; }
    public double    DefaultValue         { get; }
    public int       Published            { get; }
    public string    DisplayName          { get; }
    public int       UnitID               { get; } // TODO: STORE UNITS IN MEMORY TOO
    public int       Stackable            { get; }
    public int       HighIsGood           { get; }
    public int       CategoryID           { get; }

    public AttributeType (
        int id,                   string name,         int category,  string description, AttributeType maxAttribute, int attributeIdx, int graphicId,
        int chargeRechargeTimeId, double defaultValue, int published, string displayName, int       unitId,       int stackable,
        int highIsGood,           int    categoryId
    )
    {
        this.ID                   = id;
        this.Name                 = name;
        this.Category             = category;
        this.Description          = description;
        this.MaxAttribute         = maxAttribute;
        this.AttributeIDX         = attributeIdx;
        this.GraphicID            = graphicId;
        this.ChargeRechargeTimeID = chargeRechargeTimeId;
        this.DefaultValue         = defaultValue;
        this.Published            = published;
        this.DisplayName          = displayName;
        this.UnitID               = unitId;
        this.Stackable            = stackable;
        this.HighIsGood           = highIsGood;
        this.CategoryID           = categoryId;
    }
}