using System;
using System.Threading;
using System.Threading.Tasks;

public class CoinDescriptionPresenter
{
    private readonly ICoinDescriptionView _view;
    private readonly CoinGeckoDescriptionService _service;
    private CancellationTokenSource _cts;

    public CoinDescriptionPresenter(ICoinDescriptionView view, CoinGeckoDescriptionService service)
    {
        _view = view;
        _service = service;

        _view.OnRequestDescription += View_OnRequestDescription;
        _view.OnCancel += View_OnCancel;
    }

    private void View_OnCancel(object sender, EventArgs e)
    {
        _cts?.Cancel();
    }

    private async void View_OnRequestDescription(object sender, string coinId)
    {
        if (string.IsNullOrWhiteSpace(coinId))
        {
            _view.ShowMessage("⚠ Escribe el id de la moneda (ej: bitcoin)");
            return;
        }

        if (_cts != null)
        {
            _view.ShowMessage("Ya hay una búsqueda en curso.");
            return;
        }

        _cts = new CancellationTokenSource();
        var progress = new Progress<int>(p => _view.UpdateProgress(p));

        try
        {
            _view.ToggleLoading(true);
            _view.ShowMessage($"⏳ Buscando descripción de '{coinId}'...");

            string desc = await _service.GetDescriptionAsync(coinId, _cts.Token, progress);

            _view.ShowDescription(desc);
            _view.ShowMessage("✅ Descripción cargada.");
        }
        catch (TaskCanceledException)
        {
            _view.ShowMessage("❌ Búsqueda cancelada.");
        }
        catch (Exception ex)
        {
            _view.ShowMessage($"❗ Error: {ex.Message}");
        }
        finally
        {
            _view.ToggleLoading(false);
            _cts.Dispose();
            _cts = null;
        }
    }
}
