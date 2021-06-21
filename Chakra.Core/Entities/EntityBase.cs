﻿namespace ZenProgramming.Chakra.Core.Entities
{
    /// <summary>
    /// Represents base class for entities
    /// </summary>
    public abstract class EntityBase<TKey> : IEntity<TKey>
        where TKey: struct
    {
        /// <summary>
        /// Entity primary value
        /// </summary>
        public virtual TKey? Id { get; set; }

        /// <summary>
        /// Determines whether the specified object is equal to the current entity
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>Returns true if object are equals</returns>
        public override bool Equals(object obj)
        {
            //Se l'oggetto passato è nullo oppure non deriva dalla classe base
            //la verifica di equivalenza fallisce e posso uscire
            if (!(obj is EntityBase<TKey>))
                return false;

            //Se l'oggetto passato non è dello stesso tipo, ritorno false
            if (obj.GetType() != GetType())
                return false;

            //Sfrutto l'operatore di uguaglianza
            return (this == (EntityBase<TKey>)obj);
        }

        /// <summary>
        /// Overload for equal operator
        /// </summary>
        /// <param name="firstEntity">First member</param>
        /// <param name="secondEntity">Second member</param>
        /// <returns>Returns equality result</returns>
        public static bool operator ==(EntityBase<TKey> firstEntity, EntityBase<TKey> secondEntity)
        {
            //Verifico se sono entrambi nulli (castando ad object per evitare un loop ricorsivo)
            if ((object)firstEntity == null && (object)secondEntity == null)
                return true;

            //Verifico se almeno uno dei due è nullo
            if ((object)firstEntity == null || (object)secondEntity == null)
                return false;

            //Se uno solo è nullo
            if (firstEntity.Id == null && secondEntity.Id != null)
                return false;

            //Se uno solo è nullo
            if (firstEntity.Id != null && secondEntity.Id == null)
                return false;

            //Se i due valori sono uguali
            return firstEntity.Id.Equals(secondEntity.Id);
        }

        /// <summary>
        /// Overload for not equal operator
        /// </summary>
        /// <param name="firstEntity">First member</param>
        /// <param name="secondEntity">Second member</param>
        /// <returns>Returns not equality result</returns>
        public static bool operator !=(EntityBase<TKey> firstEntity, EntityBase<TKey> secondEntity)
        {
            //Utilizzo l'inverso dell'operatore di disuguaglianza
            return (!(firstEntity == secondEntity));
        }

        /// <summary>
        /// Returns a string that represents the entity
        /// </summary>
        /// <returns>Return entity in string format</returns>
        public override string ToString()
        {
            //Eseguo la renderizzazione formattata della stringa dell'entità corrente
            //come nome completo del tipo di dato, più Id primario dell'oggetto
            return $"{GetType().FullName} [ Id : {((Id == null) ? "null" : Id.Value.ToString())} ]";
        }

        /// <summary>
        ///  Serves as a hash function for a particular type
        /// </summary>
        /// <returns>A hash code for the current System.Object</returns>
        public override int GetHashCode()
        {
            //Utilizzo l'hascode dell'id
            return Id.GetHashCode();
        }

        /// <summary>
        /// Get primary idenyifier of entity
        /// </summary>
        /// <returns>Returns entity of enetity</returns>
        public object GetId()
        {
            //Ritorno l'id
            return Id;
        }
    }
}
