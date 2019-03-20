using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ship
{
    public class Charger: MonoBehaviour
    {
        private readonly int _totalChargesCount;
        private int _chargesCount;
        private readonly float _chargingTime;

        public List<GameObject> Charges;
        public List<Color> ChargeColors;

        private Charger()
        {
            _chargingTime = 0.4f;
            _totalChargesCount = 5;
            _chargesCount = _totalChargesCount;
        }

        public bool IsReadyToShoot()
        {
            return _totalChargesCount == _chargesCount;
        }

        public void StartCharge()
        {
            _chargesCount = 0;

            for (int i = 0; i < _totalChargesCount; i++)
                ChangeChargeColor(i, 1);

            StartCoroutine(Charge());
        }

        private IEnumerator Charge()
        {
            for (var i = 0; i < _totalChargesCount; i++)
            {
                yield return new WaitForSeconds(_chargingTime);
                _chargesCount++;

                ChangeChargeColor(_chargesCount - 1, 0);
            }
        }

        private void ChangeChargeColor(int chargeIndex, int colorIndex)
        {
            Charges[chargeIndex].GetComponent<Image>().color = ChargeColors[colorIndex];
        }
    }
}