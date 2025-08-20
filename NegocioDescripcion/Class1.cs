using System;
using System.Threading;
using System.Threading.Tasks;
using DatoDescripcion;


public class CoinDescriptionPresenter
{
    private readonly ICoinDescriptionView _view;
    private readonly CoinGeckoDescriptionService _service;

    public CoinDescriptionPresenter(ICoinDescriptionView view, CoinGeckoDescriptionService service)
    {
        _view = view;
        _service = service;

        _view.OnRequestDescription += async (s, coinId) =>
        {
            using var cts = new CancellationTokenSource();
            _view.OnCancel += (s2, e2) => cts.Cancel();

            try
            {
                _view.ShowMessage("Buscando descripción...");
                var desc = await _service.GetDescriptionAsync(coinId, cts.Token);
                _view.ShowDescription(desc);
            }
            catch (TaskCanceledException)
            {
                _view.ShowMessage("❌ Búsqueda cancelada.");
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Error: {ex.Message}");
            }
        };
    }
}

