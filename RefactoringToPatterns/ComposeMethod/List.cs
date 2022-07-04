using System;
using System.Linq;
using System.Web;

namespace RefactoringToPatterns.ComposeMethod
{
    public class List
    {

        private readonly bool _readOnly;
        private int _size;
        private Object[] _elements;

        public List(bool readOnly)
        {
            _readOnly = readOnly;
            _size = 0;
            _elements = new Object[_size];
        }

        public void Add(Object element) {
            if(!IsReadOnly())
            {
                AddNewElement(element);
            }
        }

        private bool IsReadOnly()
        {
            return _readOnly;
        }

        private void AddNewElement(object element)
        {
            if (CheckListIsFull())
            {
                AddNewPositionsToList();
            }

            _elements[_size++] = element;
        }

        private bool CheckListIsFull()
        {
            if (_size + 1 > _elements.Length)
                return true;
            return false;
        }

        private void AddNewPositionsToList()
        {
            Object[] newElements = new Object[_elements.Length + 10];

            for (int i = 0; i < _size; i++)
                newElements[i] = _elements[i];

            _elements = newElements;
        }

        public object[] Elements()
        {
            return _elements;
        }

    }

}