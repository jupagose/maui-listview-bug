using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MauiTests
{
    /// <summary>
    /// Base para la implementación de INotifyPropertyChanged
    /// </summary>
    public abstract class BaseModelPrimario : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Comprueba si una propiedad coincide ya con el valor deseado. Establece la propiedad y
        /// notifica a los agentes de escucha solo si es necesario.
        /// </summary>
        /// <typeparam name="T">Tipo de la propiedad.</typeparam>
        /// <param name="storage">Referencia a una propiedad con captador y establecedor.</param>
        /// <param name="value">Valor deseado para la propiedad.</param>
        /// <param name="propertyName">Nombre de la propiedad usada para notificar a los agentes de escucha. Este
        /// valor es opcional y se puede proporcionar automáticamente cuando se invoca desde compiladores que
        /// admiten CallerMemberName.</param>
        /// <returns>True si se cambió el valor, false si el valor existente coincidía con el
        /// valor deseado.</returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;

            this.OnPropertyChanged(propertyName);

            return true;
        }

        /// <summary>
        /// Comprueba si una propiedad coincide ya con el valor deseado. Establece la propiedad y
        /// notifica a los agentes de escucha solo si es necesario.
        /// </summary>
        /// <typeparam name="T">Tipo de la propiedad.</typeparam>
        /// <param name="storage">Referencia a una propiedad con captador y establecedor.</param>
        /// <param name="value">Valor deseado para la propiedad.</param>
        /// <param name="propertyName">Nombre de la propiedad usada para notificar a los agentes de escucha. Este
        /// valor es opcional y se puede proporcionar automáticamente cuando se invoca desde compiladores que
        /// admiten CallerMemberName.</param>
        /// <returns>True si se cambió el valor, false si el valor existente coincidía con el
        /// valor deseado.</returns>
        protected bool SetPropertyNocheckChange<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Notifica a los agentes de escucha que ha cambiado un valor de propiedad.
        /// </summary>
        /// <param name="propertyName">Nombre de la propiedad usada para notificar a los agentes de escucha. Este
        /// valor es opcional y se puede proporcionar automáticamente cuando se invoca desde compiladores
        /// que admiten <see cref="CallerMemberNameAttribute"/>.</param>
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                if (!DontHandleOnPropertyChanged)
                    eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public void LockINPC_Propagation()
        {
            DontHandleOnPropertyChanged = true;
        }

        public void UnLockINPC_Propagation()
        {
            DontHandleOnPropertyChanged = false;
        }

        /// <summary>
        /// Si es verdadero indica que no se va a propagar el evento OnPropertyChanged a los delegados.
        /// Se debe reestablecer manualmente a falso una vez realizada la operación requerida
        /// </summary>
        [NotMapped]
        public bool DontHandleOnPropertyChanged { get; set; }

        /// <summary>
        /// Indica si el objeto está actualmente realizando una operación desencadenada 
        /// por un mensjaje entrante
        /// </summary>
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public bool HandlingMessage { get; set; }

        #endregion

    }
}
