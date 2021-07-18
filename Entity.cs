using System;
using System.Collections.Generic;
namespace Nitemare3D
{
    public class Entity
    {
        public Vec2 position = new Vec2();
        public virtual void Update()
        {

        }


        public static List<Entity> entities = new List<Entity>();
        static List<Entity> entityQueue = new List<Entity>();

        static List<Entity> removeQueue = new List<Entity>();

        public static T Create<T>() where T : Entity
        {
            return Create<T>(0, 0);
        }

        public void SendMessage(string message)
        {
            GetType().GetMethod(message)?.Invoke(this, null);
        }

        public static void Add(Entity entity, Vec2 position)
        {
            entityQueue.Add(entity);
            entity.position = position;
        }

        public static void Remove(Entity entity)
        {
            removeQueue.Add(entity);
        }

        public static T Create<T>(Vec2 position) where T : Entity
        {
            return Create<T>(position.X, position.Y);
        }

        public static T Create<T>(float x, float y) where T : Entity
        {
            var entity = Activator.CreateInstance<T>();
            entity.position = new Vec2(x, y) - .5f;
            entityQueue.Add(entity);
            return entity;
        }

        public static void UpdateEntites()
        {
            foreach (var entity in entities)
            {
                entity.Update();
            }
            foreach (var entity in entityQueue)
            {
                entities.Add(entity);
            }

            foreach (var entity in removeQueue)
            {
                entities.Remove(entity);
            }

            
            entityQueue.Clear();
            removeQueue.Clear();
        }
    }
}