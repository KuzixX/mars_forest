using UnityEngine;

namespace Client.Scripts.Data
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Camera uiCamera;
        [SerializeField] private GameObject[] tileMaps;
        [SerializeField] private ParticleSystemForceField forceFieldsGold;
        [SerializeField] private ParticleSystemForceField forceFieldsExp;
        [SerializeField] private ParticleSystemForceField forceFieldsDiamonds;
        public ParticleSystemForceField ForceFieldsDiamonds => forceFieldsDiamonds;
        public ParticleSystemForceField ForceFieldsExp => forceFieldsExp;
        public ParticleSystemForceField ForceFieldsGold => forceFieldsGold;
        public Transform SpawnPoint => spawnPoint;
        public Camera MainCamera => mainCamera;
        public GameObject[] Tilemaps => tileMaps;
        public Camera UiCamera => uiCamera;
    }
}