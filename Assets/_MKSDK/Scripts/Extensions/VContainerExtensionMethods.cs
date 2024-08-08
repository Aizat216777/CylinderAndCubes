using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MKSDK
{
    public static class VContainerExtensionMethods 
    {
        public static GameObject InstantiateAndInject(
            this IObjectResolver resolver, 
            GameObject prefab, 
            Transform parent = null,
            Action<GameObject> i_OnInit = null)
        {
            if (prefab == null)
                throw new NullReferenceException(nameof(prefab));

            var prefabActive = prefab.activeSelf;

            prefab.SetActive(false);
            var instance = resolver.Instantiate(prefab, parent);
            if (i_OnInit != null)
            {
                i_OnInit.Invoke(instance);
            }
            prefab.SetActive(prefabActive);

            instance.SetActive(prefabActive);
            return instance;
        }
        public static GameObject InstantiateAndInject(
            this IObjectResolver resolver,
            GameObject prefab, 
            Vector3 i_Position,
            Quaternion i_Rotation, 
            Transform parent = null,
            Action<GameObject> i_OnInit = null)
        {
            if (prefab == null)
                throw new NullReferenceException(nameof(prefab));

            var prefabActive = prefab.activeSelf;

            prefab.SetActive(false);
            var instance = resolver.Instantiate(prefab, i_Position, i_Rotation, parent);
            if (i_OnInit != null)
            {
                i_OnInit.Invoke(instance);
            }
            prefab.SetActive(prefabActive);

            instance.SetActive(prefabActive);
            return instance;
        }
        public static T InstantiateAndInject<T>(
            this IObjectResolver resolver,
            T prefab, 
            Transform parent = null,
            Action<T> i_OnInit = null)
            where T : Component
        {
            if (prefab == null)
                throw new NullReferenceException(nameof(prefab));

            var prefabActive = prefab.gameObject.activeSelf;
            prefab.gameObject.SetActive(false);
            var instance = resolver.Instantiate(prefab, parent);
            if (i_OnInit != null)
            {
                i_OnInit.Invoke(instance);
            }
            instance.gameObject.SetActive(prefabActive);
            prefab.gameObject.SetActive(prefabActive);
            return instance;
        }
        public static T InstantiateAndInject<T>(
            this IObjectResolver resolver, 
            T prefab, 
            Vector3 i_Position,
            Quaternion i_Rotation,
            Transform parent = null,
            Action<T> i_OnInit = null)
            where T : Component
        {
            if (prefab == null)
                throw new NullReferenceException(nameof(prefab));

            var prefabActive = prefab.gameObject.activeSelf;
            prefab.gameObject.SetActive(false);
            var instance = resolver.Instantiate(prefab, i_Position, i_Rotation, parent);
            if (i_OnInit != null)
            {
                i_OnInit.Invoke(instance);
            }
            instance.gameObject.SetActive(prefabActive);
            prefab.gameObject.SetActive(prefabActive);
            return instance;
        }
    }
}