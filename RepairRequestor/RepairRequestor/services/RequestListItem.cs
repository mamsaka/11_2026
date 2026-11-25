namespace RepairRequestor.services
{
    /// <summary>
    /// Строка списка заявок для главного экрана (данные только для чтения).
    /// </summary>
    public sealed class RequestListItem
    {
        public int Id { get; set; }

        public string EmployeeName { get; set; }

        public string EquipmentTypeName { get; set; }

        public string ProblemDescription { get; set; }

        public string CreatedAt { get; set; }

        public string SpecialistName { get; set; }

        public string StatusName { get; set; }
    }
}
