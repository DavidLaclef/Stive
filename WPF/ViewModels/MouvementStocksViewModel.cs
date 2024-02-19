using Models.Dto;
using System.Collections.ObjectModel;
using WPF.Services;

namespace WPF.ViewModels;

public class MouvementStocksViewModel : BaseViewModel
{
    public ObservableCollection<MouvementStockLightDto> ListMouvementStockLights { get; set; } = new();

    public int NombreMouvementStocks { get => ListMouvementStockLights.Count(); }

    public MouvementStocksViewModel()
    {
        LoadMouvementStocks();
    }

    public void LoadMouvementStocks()
    {
        ListMouvementStockLights.Clear();
        OnPropertyChanged(nameof(NombreMouvementStocks));

        Task.Run(async () =>
        {
            return await HttpClientService.GetMouvementStockLights();
        }).ContinueWith(t =>
        {
            foreach (var MouvementStockLight in t.Result)
            {
                ListMouvementStockLights.Add(MouvementStockLight);
            }
            OnPropertyChanged(nameof(NombreMouvementStocks));
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
}
