<?php
namespace App\Test\TestCase\Model\Table;

use App\Model\Table\ShootingleveldesignTable;
use Cake\ORM\TableRegistry;
use Cake\TestSuite\TestCase;

/**
 * App\Model\Table\ShootingleveldesignTable Test Case
 */
class ShootingleveldesignTableTest extends TestCase
{

    /**
     * Test subject
     *
     * @var \App\Model\Table\ShootingleveldesignTable
     */
    public $Shootingleveldesign;

    /**
     * Fixtures
     *
     * @var array
     */
    public $fixtures = [
        'app.shootingleveldesign'
    ];

    /**
     * setUp method
     *
     * @return void
     */
    public function setUp()
    {
        parent::setUp();
        $config = TableRegistry::getTableLocator()->exists('Shootingleveldesign') ? [] : ['className' => ShootingleveldesignTable::class];
        $this->Shootingleveldesign = TableRegistry::getTableLocator()->get('Shootingleveldesign', $config);
    }

    /**
     * tearDown method
     *
     * @return void
     */
    public function tearDown()
    {
        unset($this->Shootingleveldesign);

        parent::tearDown();
    }

    /**
     * Test initialize method
     *
     * @return void
     */
    public function testInitialize()
    {
        $this->markTestIncomplete('Not implemented yet.');
    }

    /**
     * Test validationDefault method
     *
     * @return void
     */
    public function testValidationDefault()
    {
        $this->markTestIncomplete('Not implemented yet.');
    }
}
