using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public  class PatenteIterator : Iterator<Patente>
    {
        private readonly List<Patente> _patentes;
        private int _currentPosition = 0;

        public PatenteIterator(List<Patente> patentes)
        {
            _patentes = patentes;
        }

        public bool HasNext()
        {
            return _currentPosition < _patentes.Count;
        }

        public Patente GetNext()
        {
            if (HasNext())
            {
                return _patentes[_currentPosition++];
            }
            return null; // O lanza una excepción si prefieres.
        }

        public void Reset()
        {
            _currentPosition = 0;
        }
    }
}
