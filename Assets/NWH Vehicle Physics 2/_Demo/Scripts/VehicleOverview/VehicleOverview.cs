﻿using System.Collections.Generic;
using NWH.VehiclePhysics2.Powertrain.Wheel;
using NWH.Common.SceneManagement;
using UnityEngine;

namespace NWH.VehiclePhysics2.Demo.VehicleOverview
{
    public class VehicleOverview : MonoBehaviour
    {
        public static VehicleOverview Instance;
        
        public VehicleController vc;
        public Transform parent;
        public GameObject wheelGroupPrefab;

        private List<WheelGroupUI> wheelGroupUIs = new List<WheelGroupUI>();
        private VehicleController _prevVc;

        private void Awake()
        {
            Instance = this;
        }

        void Initialize()
        {
            foreach (Transform t in parent)
            {
                if (t.name == "VehicleOverviewLegend")
                {
                    continue;
                }
                Destroy(t.gameObject);
            }
            
            foreach (WheelGroup wheelGroup in vc.powertrain.wheelGroups)
            {
                wheelGroupUIs.Add(InitGroupUI(wheelGroup));
            }
        }

        private WheelGroupUI InitGroupUI(WheelGroup wheelGroup)
        {
            WheelGroupUI wheelGroupUI = Instantiate(wheelGroupPrefab, parent).GetComponent<WheelGroupUI>();
            wheelGroupUI.Initialize(wheelGroup);
            return wheelGroupUI;
        }

        void Update()
        {
            vc = VehicleChanger.ActiveVehicle as VehicleController;
            if (vc == null)
            {
                return;
            }

            if (_prevVc != vc)
            {
                Initialize();
            }

            _prevVc = vc;
        }

        private Color GetColorFromValue(float currentValue, float maxValue)
        {
            float rgb = Mathf.Clamp01(currentValue / maxValue);
            return new Color(rgb, rgb, rgb, 1f);
        }
    }
}


