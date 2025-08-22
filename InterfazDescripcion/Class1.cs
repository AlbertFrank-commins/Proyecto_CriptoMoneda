// Interfaz que define el contrato para una vista que muestra la descripción de una criptomoneda
public interface ICoinDescriptionView
{
    // Evento que se dispara cuando el usuario solicita la descripción de una moneda.
    // El string representa el identificador o nombre de la moneda que se quiere consultar.
    event EventHandler<string> OnRequestDescription;

    // Evento que se dispara cuando el usuario cancela la operación de búsqueda o carga.
    event EventHandler OnCancel;

    // Muestra un mensaje genérico en la vista (puede ser un error, información o advertencia)
    void ShowMessage(string message);

    // Muestra la descripción de la criptomoneda en la vista.
    void ShowDescription(string description);

    // Actualiza el progreso de la operación en la vista (por ejemplo, una barra de progreso)
    void UpdateProgress(int value);

    // Muestra u oculta algún indicador de carga (spinner, overlay, etc.) según el parámetro.
    void ToggleLoading(bool isLoading);
}





