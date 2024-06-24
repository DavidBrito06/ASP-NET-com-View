using br.com.fiap.alert.Models;
using System.Collections.Generic;

namespace br.com.fiap.alert.ViewModel
{
    public class AlertPaginacaoViewModel
    {
        public IEnumerable<AlertModel> Alerts { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage { get; set; }
        public string PreviousPageUrl => HasPreviousPage ? $"/Alert/IndexPaginated?pagina={CurrentPage - 1}&tamanhoPagina={PageSize}" : "";
        public string NextPageUrl => HasNextPage ? $"/Alert/IndexPaginated?pagina={CurrentPage + 1}&tamanhoPagina={PageSize}" : "";
        public void SetPaginationValues(int totalItems)
        {
            HasNextPage = (CurrentPage * PageSize) < totalItems;
        }
        public int TotalPages { get; set; } 
    }
}
