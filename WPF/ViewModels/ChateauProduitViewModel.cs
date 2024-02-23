using Models.Dao;
using Models.Dto;
using Models.Enums;
using System.Collections.ObjectModel;
using WPF.Services;

namespace WPF.ViewModels;

public class ChateauProduitViewModel : ProduitsViewModel
{

    public ChateauProduitViewModel()
    {
        LoadProduits();
        LoadChateaux();
    }

}
