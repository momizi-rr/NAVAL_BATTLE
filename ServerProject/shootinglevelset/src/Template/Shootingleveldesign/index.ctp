<?php
/**
 * @var \App\View\AppView $this
 * @var \App\Model\Entity\Shootingleveldesign[]|\Cake\Collection\CollectionInterface $shootingleveldesign
 */
?>
<nav class="large-3 medium-4 columns" id="actions-sidebar">
    <ul class="side-nav">
        <li class="heading"><?= __('Actions') ?></li>
        <li><?= $this->Html->link(__('New Shootingleveldesign'), ['action' => 'add']) ?></li>
    </ul>
</nav>
<div class="shootingleveldesign index large-9 medium-8 columns content">
    <h3><?= __('Shootingleveldesign') ?></h3>
    <table cellpadding="0" cellspacing="0">
        <thead>
            <tr>
                <th scope="col"><?= $this->Paginator->sort('Number') ?></th>
                <th scope="col"><?= $this->Paginator->sort('Level') ?></th>
                <th scope="col"><?= $this->Paginator->sort('Pattern') ?></th>
                <th scope="col"><?= $this->Paginator->sort('PosX') ?></th>
                <th scope="col"><?= $this->Paginator->sort('PosY') ?></th>
                <th scope="col"><?= $this->Paginator->sort('PosZ') ?></th>
                <th scope="col"><?= $this->Paginator->sort('RateX') ?></th>
                <th scope="col"><?= $this->Paginator->sort('RateY') ?></th>
                <th scope="col"><?= $this->Paginator->sort('RateZ') ?></th>
                <th scope="col"><?= $this->Paginator->sort('ScaleX') ?></th>
                <th scope="col"><?= $this->Paginator->sort('ScaleY') ?></th>
                <th scope="col"><?= $this->Paginator->sort('ScaleZ') ?></th>
                <th scope="col" class="actions"><?= __('Actions') ?></th>
            </tr>
        </thead>
        <tbody>
            <?php foreach ($shootingleveldesign as $shootingleveldesign): ?>
            <tr>
                <td><?= $this->Number->format($shootingleveldesign->Number) ?></td>
                <td><?= $this->Number->format($shootingleveldesign->Level) ?></td>
                <td><?= $this->Number->format($shootingleveldesign->Pattern) ?></td>
                <td><?= $this->Number->format($shootingleveldesign->PosX) ?></td>
                <td><?= $this->Number->format($shootingleveldesign->PosY) ?></td>
                <td><?= $this->Number->format($shootingleveldesign->PosZ) ?></td>
                <td><?= $this->Number->format($shootingleveldesign->RateX) ?></td>
                <td><?= $this->Number->format($shootingleveldesign->RateY) ?></td>
                <td><?= $this->Number->format($shootingleveldesign->RateZ) ?></td>
                <td><?= $this->Number->format($shootingleveldesign->ScaleX) ?></td>
                <td><?= $this->Number->format($shootingleveldesign->ScaleY) ?></td>
                <td><?= $this->Number->format($shootingleveldesign->ScaleZ) ?></td>
                <td class="actions">
                    <?= $this->Html->link(__('View'), ['action' => 'view', $shootingleveldesign->Number]) ?>
                    <?= $this->Html->link(__('Edit'), ['action' => 'edit', $shootingleveldesign->Number]) ?>
                    <?= $this->Form->postLink(__('Delete'), ['action' => 'delete', $shootingleveldesign->Number], ['confirm' => __('Are you sure you want to delete # {0}?', $shootingleveldesign->Number)]) ?>
                </td>
            </tr>
            <?php endforeach; ?>
        </tbody>
    </table>
    <div class="paginator">
        <ul class="pagination">
            <?= $this->Paginator->first('<< ' . __('first')) ?>
            <?= $this->Paginator->prev('< ' . __('previous')) ?>
            <?= $this->Paginator->numbers() ?>
            <?= $this->Paginator->next(__('next') . ' >') ?>
            <?= $this->Paginator->last(__('last') . ' >>') ?>
        </ul>
        <p><?= $this->Paginator->counter(['format' => __('Page {{page}} of {{pages}}, showing {{current}} record(s) out of {{count}} total')]) ?></p>
    </div>
</div>
