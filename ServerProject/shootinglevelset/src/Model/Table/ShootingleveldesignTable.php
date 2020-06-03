<?php
namespace App\Model\Table;

use Cake\ORM\Query;
use Cake\ORM\RulesChecker;
use Cake\ORM\Table;
use Cake\Validation\Validator;

/**
 * Shootingleveldesign Model
 *
 * @method \App\Model\Entity\Shootingleveldesign get($primaryKey, $options = [])
 * @method \App\Model\Entity\Shootingleveldesign newEntity($data = null, array $options = [])
 * @method \App\Model\Entity\Shootingleveldesign[] newEntities(array $data, array $options = [])
 * @method \App\Model\Entity\Shootingleveldesign|bool save(\Cake\Datasource\EntityInterface $entity, $options = [])
 * @method \App\Model\Entity\Shootingleveldesign|bool saveOrFail(\Cake\Datasource\EntityInterface $entity, $options = [])
 * @method \App\Model\Entity\Shootingleveldesign patchEntity(\Cake\Datasource\EntityInterface $entity, array $data, array $options = [])
 * @method \App\Model\Entity\Shootingleveldesign[] patchEntities($entities, array $data, array $options = [])
 * @method \App\Model\Entity\Shootingleveldesign findOrCreate($search, callable $callback = null, $options = [])
 */
class ShootingleveldesignTable extends Table
{

    /**
     * Initialize method
     *
     * @param array $config The configuration for the Table.
     * @return void
     */
    public function initialize(array $config)
    {
        parent::initialize($config);

        $this->setTable('shootingleveldesign');
        $this->setDisplayField('Number');
        $this->setPrimaryKey('Number');
    }

    /**
     * Default validation rules.
     *
     * @param \Cake\Validation\Validator $validator Validator instance.
     * @return \Cake\Validation\Validator
     */
    public function validationDefault(Validator $validator)
    {
        $validator
            ->integer('Number')
            ->allowEmpty('Number', 'create');

        $validator
            ->integer('Level')
            ->requirePresence('Level', 'create')
            ->notEmpty('Level');

        $validator
            ->integer('Pattern')
            ->requirePresence('Pattern', 'create')
            ->notEmpty('Pattern');

        $validator
            ->integer('PosX')
            ->requirePresence('PosX', 'create')
            ->notEmpty('PosX');

        $validator
            ->integer('PosY')
            ->requirePresence('PosY', 'create')
            ->notEmpty('PosY');

        $validator
            ->integer('PosZ')
            ->requirePresence('PosZ', 'create')
            ->notEmpty('PosZ');

        $validator
            ->integer('RateX')
            ->requirePresence('RateX', 'create')
            ->notEmpty('RateX');

        $validator
            ->integer('RateY')
            ->requirePresence('RateY', 'create')
            ->notEmpty('RateY');

        $validator
            ->integer('RateZ')
            ->requirePresence('RateZ', 'create')
            ->notEmpty('RateZ');

        $validator
            ->integer('ScaleX')
            ->requirePresence('ScaleX', 'create')
            ->notEmpty('ScaleX');

        $validator
            ->integer('ScaleY')
            ->requirePresence('ScaleY', 'create')
            ->notEmpty('ScaleY');

        $validator
            ->integer('ScaleZ')
            ->requirePresence('ScaleZ', 'create')
            ->notEmpty('ScaleZ');

        return $validator;
    }
}
