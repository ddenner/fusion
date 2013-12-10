namespace FusionServices.Contracts.Data
{
    /// <summary>
    /// This defines the federated partition and must be available for all federated tables that are done by region/hash.
    /// </summary>
    public interface IFederatedKey
    {
        int Key { get; set; }
    }
}
