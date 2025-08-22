using System;
using System.Threading;
using System.Threading.Tasks;

// TODO: Presentador que maneja la lógica entre la vista de descripción de monedas y el servicio de CoinGecko
public class CoinDescriptionPresenter
{
    // TODO: Vista que implementa ICoinDescriptionView
    private readonly ICoinDescriptionView _view;

    // TODO: Servicio que obtiene la descripción de la criptomoneda desde CoinGecko
    private readonly CoinGeckoDescriptionService _service;

    // TODO: Fuente de cancelación para detener búsquedas en curso
    private CancellationTokenSource _cts;

    // TODO: Constructor que recibe la vista y el servicio
    public CoinDescriptionPresenter(ICoinDescriptionView view, CoinGeckoDescriptionService service)
    {
        _view = view;
        _service = service;

        // TODO: Suscribe los eventos de la vista a los manejadores correspondientes
        _view.OnRequestDescription += View_OnRequestDescription;
        _view.OnCancel += View_OnCancel;
    }

    // TODO: Manejador del evento OnCancel de la vista
    // TODO: Cancela la búsqueda en curso si existe
    private void View_OnCancel(object sender, EventArgs e)
    {
        _cts?.Cancel();
    }

    // TODO: Manejador del evento OnRequestDescription de la vista
    // TODO: Ejecuta la búsqueda de la descripción de la moneda de manera asincrónica
    private async void View_OnRequestDescription(object sender, string coinId)
    {
        // TODO: Valida que el ID de la moneda no esté vacío
        if (string.IsNullOrWhiteSpace(coinId))
        {
            _view.ShowMessage("⚠ Escribe el id de la moneda (ej: bitcoin)");
            return;
        }

        // TODO: Evita iniciar otra búsqueda si ya hay una en curso
        if (_cts != null)
        {
            _view.ShowMessage("Ya hay una búsqueda en curso.");
            return;
        }

        // TODO: Crea un nuevo CancellationTokenSource para esta operación
        _cts = new CancellationTokenSource();

        // TODO: Crea un progreso que actualiza la barra de progreso en la vista
        var progress = new Progress<int>(p => _view.UpdateProgress(p));

        try
        {
            // TODO: Muestra indicador de carga y mensaje inicial
            _view.ToggleLoading(true);
            _view.ShowMessage($"⏳ Buscando descripción de '{coinId}'...");

            // TODO: Llama al servicio para obtener la descripción de la moneda
            string desc = await _service.GetDescriptionAsync(coinId, _cts.Token, progress);

            // TODO: Muestra la descripción y mensaje de éxito en la vista
            _view.ShowDescription(desc);
            _view.ShowMessage("✅ Descripción cargada.");
        }
        catch (TaskCanceledException)
        {
            // TODO: Maneja la cancelación de la búsqueda
            _view.ShowMessage("❌ Búsqueda cancelada.");
        }
        catch (Exception ex)
        {
            // TODO: Maneja errores inesperados y los muestra en la vista
            _view.ShowMessage($"❗ Error: {ex.Message}");
        }
        finally
        {
            // TODO: Oculta el indicador de carga y libera recursos
            _view.ToggleLoading(false);
            _cts.Dispose();
            _cts = null;
        }
    }
}

