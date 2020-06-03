<?php
namespace App\Model\Entity;

use Cake\ORM\Entity;

/**
 * Shootingleveldesign Entity
 *
 * @property int $Number
 * @property int $Level
 * @property int $Pattern
 * @property int $PosX
 * @property int $PosY
 * @property int $PosZ
 * @property int $RateX
 * @property int $RateY
 * @property int $RateZ
 * @property int $ScaleX
 * @property int $ScaleY
 * @property int $ScaleZ
 */
class Shootingleveldesign extends Entity
{

    /**
     * Fields that can be mass assigned using newEntity() or patchEntity().
     *
     * Note that when '*' is set to true, this allows all unspecified fields to
     * be mass assigned. For security purposes, it is advised to set '*' to false
     * (or remove it), and explicitly make individual fields accessible as needed.
     *
     * @var array
     */
    protected $_accessible = [
        'Level' => true,
        'Pattern' => true,
        'PosX' => true,
        'PosY' => true,
        'PosZ' => true,
        'RateX' => true,
        'RateY' => true,
        'RateZ' => true,
        'ScaleX' => true,
        'ScaleY' => true,
        'ScaleZ' => true
    ];
}
